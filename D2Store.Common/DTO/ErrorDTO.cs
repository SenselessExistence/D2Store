﻿using System.Text.Json;

namespace D2Store.Common.DTO
{
    public class ErrorDTO
    {
        public int StatusCode { get; set; }

        public string Message { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
