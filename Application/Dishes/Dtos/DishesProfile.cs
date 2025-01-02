using AutoMapper;
using Domain.Entities;

namespace Application.Dtos;

public class DishProfile : Profile
{

    public DishProfile() => CreateMap<Dish, DishDto>();
}
