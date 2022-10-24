namespace DapperDeneme.Dto
{
    public record FactoryDto(int FactoryId,string factoryname, int baseValue)
    {
        //Record çalışma zamanında kalıtım aldığı için içerisine değer atılırken eğer select sorgusu doğrudan eşleşmez ise yani * kullanılırsa bu constructor tanımlanmalı.
        public FactoryDto() : this(default, default, default) { }
    }
}
