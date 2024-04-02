Example how to use Extensions
```csharp
using AutoMapper;
using PetrolMuffin.AutoMapper.Extensions;

public class Source
{
    public string Name { get; set; }
}

public class Destination
{
    public string Name { get; set; }
}

public class Mapper
{
    private readonly IMapper _mapper;
    
    public Mapper()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Source, Destination>()
               .From(s => s.Name).To(d => d.Name);
        });

        _mapper = config.CreateMapper();
    }
    
    public Destination Map(Source source) => _mapper.Map<Destination>(source);
}
```