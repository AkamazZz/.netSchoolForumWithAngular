using System;


namespace BusinessLogicLayer.Services.Models
{
    //WILL BE USED AS EVERY RESULT OBJECT FROM OUR SERVICE METHODS
    public class Generic_ResultSet<T>:StandardResultObject
    {
        public T result_set { get; set; }
    }
}
