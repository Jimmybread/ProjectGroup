using ChinaSoftRCW.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChinaSoftRCW.Utilities
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>().HasData(
               new Project
               {
                   Id = 1,
                   ProjectName = "Microsoft-BingFeedBack"
               },
               new Project
               {
                   Id = 2,
                   ProjectName = "Microsoft-WrapStar"
               },
               new Project
               {
                   Id = 3,
                   ProjectName = "Microsoft-Insider"
               },
               new Project
               {
                   Id = 4,
                   ProjectName = "Microsoft-AD"
               },
                new Project
                {
                    Id = 5,
                    ProjectName = "Microsoft-Azure"
                }
            );

            modelBuilder.Entity<TechStack>().HasData(
                new TechStack
                {
                    Id = 1,
                    TechName = "C#"
                },
                new TechStack
                {
                    Id = 2,
                    TechName = ".NET"
                },
                new TechStack
                {
                    Id = 3,
                    TechName = "Java"
                }
            );

            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    Id = 1,
                    RoleName = ConstStrings.HR
                },
                new Role
                {
                    Id = 2,
                    RoleName = ConstStrings.Interviewer
                },
                new Role
                {
                    Id = 3,
                    RoleName = ConstStrings.PM
                },
                new Role
                {
                    Id = 4,
                    RoleName = ConstStrings.Client
                }
            );

            modelBuilder.Entity<Gender>().HasData(
                new Gender
                {
                    Id = 1,
                    GenderName = "男"
                },
                new Gender
                {
                    Id = 2,
                    GenderName = "女"
                },
                new Gender
                {
                    Id = 3,
                    GenderName = "保密"
                }
             );

            modelBuilder.Entity<JobState>().HasData(
                new JobState
                {
                    Id = 1,
                    JobStateName = "在职"
                },
                new JobState
                {
                    Id = 2,
                    JobStateName = "已离职"
                },
                new JobState
                {
                    Id = 3,
                    JobStateName = "观望"
                }
             );
        }
    }
}
