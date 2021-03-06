// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IoC.cs" company="Web Advanced">
// Copyright 2012 Web Advanced (www.webadvanced.com)
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0

// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


using System.Configuration;
using Management.Library;
using ServiceContracts;
using StructureMap;
using win10Core.Business;

namespace Services.DependencyResolution {
    public static class IoC {
        public static IContainer Initialize() {
            //var container = new Container(_ =>
            //{
            //    _.Scan(x =>
            //    {
            //        x.TheCallingAssembly();
            //        x.WithDefaultConventions();
            //    });
            //});

            var registry = new Registry();
            registry.IncludeRegistry<PurpleRegistry>();
            // build a container
            var container = new Container(registry);

            return container;
        }

        public class PurpleRegistry : Registry
        {
            public PurpleRegistry()
            {

                For<IServiceSettings>().Use(new ServiceSettings(ConfigHelper.GetSetting("ServiceURL")));
                For<IServiceLayers>().Use<ServiceLayers>();
                //For<IDBContext>().Use<DBContext>();
                For<IServiceSetting>().Use(new ServiceSetting(ConfigHelper.GetSetting("ServiceURL")));
                //For<IServiceSetting>().Use<ServiceSetting>();
                For<IServiceLayer>().Use<ServiceLayer>();
                //For<ILogInfoDataAccess>().Use<LogInfoDataAccess>();
                //For<ILogErrorDataAccess>().Use<LogErrorDataAccess>();
                //For<ILogEngine>().Use<LogEngine>();
                //For<IFamilyDataAccess>().Use<FamilyDataAccess>();
                //For<IParentDataAccess>().Use<ParentDataAccess>();
                //For<IKidDataAccess>().Use<KidDataAccess>();
                //For<IGiftDataAccess>().Use<GiftDataAccess>();
                //For<IEmailEngine>().Use<EmailEngine>();

                //For<IEmailConfiguration>().Use<EmailConfiguration>();

                //For<ISubject>().Use<Subject>();
            }
        }
    }
}