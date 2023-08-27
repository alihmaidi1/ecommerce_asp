
namespace ecommerce.Dto
{
    public  class ExternalRegionDto<T>
    {

        public bool error { get;set; }
        public string msg { get; set; }

        public T data { get; set; } 


    }



}
