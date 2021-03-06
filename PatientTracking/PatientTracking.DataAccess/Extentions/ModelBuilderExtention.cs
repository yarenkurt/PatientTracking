﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace PatientTracking.DataAccess.Extentions
{
    public static class ModelBuilderExtensions
    {
        public static ModelBuilder MapConfiguration(this ModelBuilder mb)
        {
            return mb.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public static ModelBuilder SetDataType(this ModelBuilder mb)
        {
            foreach (var fk in mb.Model.GetEntityTypes().SelectMany(t => t.GetForeignKeys()).Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade))
            {
                fk.DeleteBehavior = DeleteBehavior.Restrict;
            }

            foreach (var property in mb.Model.GetEntityTypes().SelectMany(t => t.GetProperties().OrderBy(x => x.Name)))
            {

                if (property.ClrType == typeof(decimal))
                {
                    property.SetColumnType("decimal(18,4)");
                }
                if (property.ClrType == typeof(double))
                {
                    property.SetColumnType("money");
                }
                if (property.ClrType == typeof(bool))
                {
                    property.SetDefaultValue(false);
                }

                if (property.ClrType == typeof(byte) || property.ClrType == typeof(short) || property.ClrType == typeof(float) || property.ClrType == typeof(double) || property.ClrType == typeof(decimal))
                {
                    property.SetDefaultValue(0);
                }
                else if (property.ClrType == typeof(Guid))
                {
                    property.SetDefaultValueSql("NewId()");
                }
                else if (property.ClrType == typeof(string))
                {
                    property.IsNullable = false;
                    property.SetDefaultValueSql("space(0)");
                }
                else if (property.ClrType == typeof(DateTime) && !property.IsNullable)
                {
                    property.SetDefaultValueSql("Convert(Date,GetDate())");
                }
                else if (property.ClrType == typeof(TimeSpan))
                {
                    property.SetDefaultValueSql("00:00:00");
                }

                switch (property.Name)
                {

                    case "FirstName":
                    case "LastName":
                        property.SetMaxLength(50);
                        break;

                    case "Email":
                    case "Description":
                    case "CreatedUserName":
                        property.SetMaxLength(100);
                        break;

                    case "Gsm":
                    case "Phone":
                        property.SetMaxLength(11);
                        break;


                }

            }

            return mb;
        }
    }
}
