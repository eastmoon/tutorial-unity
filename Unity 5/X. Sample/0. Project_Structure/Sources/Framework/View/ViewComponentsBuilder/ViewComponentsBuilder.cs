using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

namespace Game.Framework.View.ViewComponentsBuilder
{
    class ViewComponentsBuilder : IViewComponentsBuilder
    {
        // Member variable
        private String mComponentID;
        private Hashtable mBuilderTable;
        private GameObject mStage;
        // Constructor
        public ViewComponentsBuilder()
        {
            this.mBuilderTable = new Hashtable();
            this.mStage = null;
        }
        // Setting builder method
        public IViewComponentsBuilder SetBuilder(IViewComponentsBuilder _builder)
        {
            if (this.mBuilderTable[_builder.GetComponentID()] == null)
                this.mBuilderTable.Add(_builder.GetComponentID(), _builder);
            else
                this.mBuilderTable[_builder.GetComponentID()] = _builder;
            return this;
        }
        public IViewComponentsBuilder SetStage(GameObject _stage)
        {
            this.mStage = _stage;
            return this;
        }

        // Get / Set method
        protected GameObject GetStage()
        {
            return this.mStage;
        }
        protected void SetComponentID(String _componentID)
        {
            this.mComponentID = _componentID;
        }
        public String GetComponentID()
        {
            return this.mComponentID;
        }
        // Build component
        public virtual GameObject Build(params object[] _args)
        {
            return null;
        }
        public GameObject Build(String _componentID, params object[] _args)
        {
            IViewComponentsBuilder builder = this.mBuilderTable[_componentID] as IViewComponentsBuilder;
            if (builder != null) { 
                return builder.SetStage(this.mStage).Build(_args);
            }
            return null;
        }
        public GameObject Build(String _componentID, GameObject _stage, params object[] _args)
        {
            return this.SetStage(_stage).Build(_componentID, _args);
        }
    }
}
