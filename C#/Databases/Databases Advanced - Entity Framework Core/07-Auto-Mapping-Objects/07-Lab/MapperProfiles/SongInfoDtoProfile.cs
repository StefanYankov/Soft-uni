using System.Linq;
using _07_Lab_Demo.Models;
using AutoMapper;

namespace _07_Lab_Demo.MapperProfiles
{
    public class SongInfoDtoProfile : Profile
    {
        public SongInfoDtoProfile()
        {
            this.CreateMap<Song, SongInfoDto>()
                // config custom mapping
                .ForMember(x => x.Artists, options =>
                {
                    options.MapFrom(x =>
                        string.Join(", ", x.SongArtists.Select(a => a.Artist.Name)));
                })  
                .ReverseMap();
        }
    }
}
