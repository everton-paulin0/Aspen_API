﻿namespace Aspen_API.Services
{
    public interface IConfigServicecs
    {
        int GetValue();
    }

    public class ConfigService : IConfigService
    {
        private int _value;
        public int GetValue()
        {
            _value++;

            return _value;
        }

    }
}