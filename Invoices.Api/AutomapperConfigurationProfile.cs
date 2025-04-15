
using AutoMapper;
using Invoices.Api.Models;
using Invoices.Data.Models;

namespace Invoices.Api;

public class AutomapperConfigurationProfile : Profile
{
    public AutomapperConfigurationProfile()
    {
        CreateMap<Person, PersonDto>();
        CreateMap<PersonDto, Person>();

        CreateMap<Invoice, InvoiceDto>();
        CreateMap<InvoiceDto, Invoice>();

        CreateMap<GlobalStatisticsDto, GlobalStatistics>();
        CreateMap<GlobalStatistics, GlobalStatisticsDto>();

        CreateMap<PersonsStatistics, PersonsStatisticsDto>();
        CreateMap<PersonsStatisticsDto, PersonsStatistics>();
    }
}