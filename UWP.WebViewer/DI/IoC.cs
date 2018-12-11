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


using StructureMap;
using universalwindows.library.Common;

namespace UniversalWindows.DI {
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
                For<IPersonBusiness>().Use<PersonBusiness>();
                //For<ISubject>().Use<Subject>();
            }
        }
    }
}