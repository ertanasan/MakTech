// Created by OverGenerator
/*Section="Usings"*/
using System;

namespace Overtech.DataModels.Product
{
    internal class OTDataFieldAttribute : Attribute
    {
        private string v;

        public OTDataFieldAttribute(string v)
        {
            this.v = v;
        }
    }
}