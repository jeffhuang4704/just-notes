using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace efcore.console.Models
{
    public class Applicant
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
    }

    public class ApplicantDbContext: DbContext
    {
        public DbSet<Applicant> Applicants { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            string sqliteFile = @"applicants.db";
            string cnString = string.Format("Data Source={0}", sqliteFile);
            optionsBuilder.UseSqlite(cnString);
        }
    } 

    public class AppDemo
    {
        public AppDemo()
        {

        }

        public void Run()
        {
            using (var context = new ApplicantDbContext())
            {
                var applicants = context.Applicants.ToList();
                foreach(var applicant in applicants)
                {
                    Console.WriteLine(string.Format("FirstName: {0}, LastName: {1}", applicant.firstName, applicant.lastName));
                }
            }
        }
    }
}
