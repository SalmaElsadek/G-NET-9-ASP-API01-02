using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace E_Commerce.Application.Common
{
    public sealed record Error(string Code,String Description,ErrorType ErrorType=ErrorType.Failure)
    {
        public static Error Failure(string Code="General.Failure",string Description="General Failure Has Occured")=> new(Code,Description,ErrorType.Failure);
        public static Error Validation(string Code= "General.Validation", string Description= "General Validation Error Has Occured") => new(Code,Description,ErrorType.Validation);
        public static Error NotFound(string Code= "General.NotFound", string Description= "Resources NotFound") => new(Code,Description,ErrorType.NotFound);
        public static Error Conflict(string Code= "General.Conflict", string Description= "General Conflict Error Has Occured") => new(Code,Description,ErrorType.Conflict);
        public static Error Unuthorized(string Code= "General.Unuthorized", string Description= "Acces Is Denied Due To Bad Authorization") => new(Code,Description,ErrorType.Unuthorized);
        public static Error Forbidden(string Code= "General.Forbidden", string Description= "This operation is forbidden") => new(Code,Description,ErrorType.Forbidden);
        public static Error InValidCredentials(string Code= "General.InValidCredentials", string Description= "Provided Credentials are invalid ") => new(Code,Description,ErrorType.InValidCredentials);


    }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ErrorType
    {
        Failure=0,
        Validation,
        NotFound,
        Conflict,
        Unuthorized,
        Forbidden,
        InValidCredentials
    }
}
