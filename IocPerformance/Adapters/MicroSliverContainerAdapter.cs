﻿using System;
using MicroSliver;

namespace IocPerformance.Adapters
{
    public sealed class MicroSliverContainerAdapter : ContainerAdapterBase
    {
        private IoC container;

        protected override string PackageName
        {
            get { return "MicroSliver"; }
        }

        public override void Prepare()
        {
            this.container = new IoC();
            this.container.Map<ISingleton, Singleton>().ToSingletonScope();
            this.container.Map<ITransient, Transient>();
            this.container.Map<ICombined, Combined>();
        }

        public override object Resolve(Type type)
        {
            return this.container.GetByType(type);
        }

        public override void Dispose()
        {
            // Allow the container and everything it references to be disposed.
            this.container = null;
        }
    }
}