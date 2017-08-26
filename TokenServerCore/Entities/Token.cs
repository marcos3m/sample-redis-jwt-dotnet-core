using System;
using System.Collections.Generic;
using System.Text;

namespace TokenServerCore.Entities
{
    public class Token
    {
        public string Key { get; set; }
        public string Value { get; set; }

        public bool IsValid()
        {
            var isValid = true;

            if (string.IsNullOrEmpty(Key))
                return false;

            if (string.IsNullOrEmpty(Value))
                return false;

            return isValid;
        }
    }
}
