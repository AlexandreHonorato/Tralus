﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Chart;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.PivotChart;
using DevExpress.ExpressApp.PivotGrid;
using DevExpress.ExpressApp.ReportsV2;
using DevExpress.ExpressApp.TreeListEditors;
using DevExpress.ExpressApp.Validation;
using DevExpress.ExpressApp.ViewVariantsModule;
using DevExpress.ExpressApp.Workflow;
using Tralus.Framework.BusinessModel.Entities;
using Tralus.Framework.Module.Interface;
using Tralus.Framework.Utility.ReflectionHelpers;

namespace Tralus.Framework.Module
{
    public class TralusModule : ModuleBase
    {
        protected TralusModule()
        {
            var entityTypes =
                AssemblyResolver.GetCurrentModuleTypes(GetType())
                    .Where(e => e.IsSubclassOf(typeof (EntityBase)) && !e.IsAbstract);

            AdditionalExportedTypes.Add(typeof(EntityBase));

            foreach (var entity in entityTypes)
            {
                AdditionalExportedTypes.Add(entity);
            }

            this.RequiredModuleTypes.Add(typeof(ConditionalAppearanceModule));
            this.RequiredModuleTypes.Add(typeof(ValidationModule));
            this.RequiredModuleTypes.Add(typeof(ViewVariantsModule));
            this.RequiredModuleTypes.Add(typeof(ReportsModuleV2));
            this.RequiredModuleTypes.Add(typeof(TreeListEditorsModuleBase));
            this.RequiredModuleTypes.Add(typeof(ChartModule));
            this.RequiredModuleTypes.Add(typeof(PivotGridModule));
            this.RequiredModuleTypes.Add(typeof(PivotChartModuleBase));
            this.RequiredModuleTypes.Add(typeof(WorkflowModule));
        }
    }
}
