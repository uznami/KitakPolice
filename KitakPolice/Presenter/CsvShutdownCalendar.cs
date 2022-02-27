using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using KitakPolice.Domain;
using KitakPolice.Domain.OutputPort;

namespace KitakPolice.Presenter
{
    class CsvShutdownCalendar : IShutdownCalendar
    {
        static readonly string CsvFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Kitak Police\\plan.csv");

        public ShutdownPlan? LookupPlan(DateTime date)
        {
            foreach (var plan in LoadPlanList())
            {
                if (date.Date == plan.Time.Date)
                {
                    return plan;
                }
            }
            return null;
        }

        public void StorePlan(ShutdownPlan plan)
        {
            var found = false;
            var plans = LoadPlanList().Select(p =>
            {
                if (plan.Time.Date == p.Time.Date)
                {
                    found = true;
                    return plan;
                }
                else
                {
                    return p;
                }
            }).ToList();
            if (!found)
            {
                plans.Add(plan);
            }
            StorePlanList(plans);
        }

        ShutdownPlan ParsePlan(string[] row)
        {
            if (row.Length > 3 && row[3] != "" && row[3].All(Char.IsDigit))
            {
                return new ShutdownPlan
                {
                    Time = DateTime.Parse(row[0]).Add(TimeSpan.Parse(row[1])),
                    Kind = ParseKind(row[2]) ?? ExecutionKind.Shutdown,
                    ReminderBefore = (TimeSpan?)TimeSpan.FromMinutes(int.Parse(row[3])),
                };
            }
            return new ShutdownPlan
            {
                Time = DateTime.Parse(row[0]).Add(TimeSpan.Parse(row[1])),
                Kind = ParseKind(row[2]) ?? ExecutionKind.Shutdown,
                ReminderBefore = null, 
            };
        }

        List<ShutdownPlan> LoadPlanList()
        {
            if (!File.Exists(CsvFilePath))
            {
                return new List<ShutdownPlan>();
            }
            return File.ReadAllLines(CsvFilePath)
                .Where(line => line.Length > 0)
                .Select(line => ParsePlan(line.Split(',')))
                .ToList();
        }

        void StorePlanList(List<ShutdownPlan> plans)
        {
            plans.Sort((a, b) => a.Time.CompareTo(b.Time));
            using (var file = File.OpenWrite(CsvFilePath))
            using (var writer = new StreamWriter(file))
            {
                foreach (var plan in plans)
                {
                    writer.Write($"{plan.Time.Year:d4}/{plan.Time.Month:d2}/{plan.Time.Day:d2}");
                    writer.Write($",{plan.Time.Hour:d2}:{plan.Time.Minute:d2}:{plan.Time.Second}");
                    writer.Write($",{FormatKind(plan.Kind)}");
                    if (plan.ReminderBefore is TimeSpan span)
                    {
                        writer.WriteLine($",{(int)span.TotalMinutes}");
                    }
                    else
                    {
                        writer.WriteLine();
                    }
                }
            }
        }

        ExecutionKind? ParseKind(string kind)
        {
            switch (kind)
            {
                case "shutdown": return ExecutionKind.Shutdown;
                case "hibernate": return ExecutionKind.Hibernate;
                case "logoff": return ExecutionKind.Logoff;
                default: return null;
            }
        }

        string FormatKind(ExecutionKind kind)
        {
            switch (kind)
            {
                case ExecutionKind.Shutdown: return "shutdown";
                case ExecutionKind.Hibernate: return "hibernate";
                case ExecutionKind.Logoff: return "logoff";
                default: return "shutdown";
            }
        }
    }
}
