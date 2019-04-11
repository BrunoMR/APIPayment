namespace WebApi.Profile
{
    using AutoMapper;

    using WebApi.Extensions;
    using WebApi.Models;

    public class CybersourceUpdateProfile : Profile
    {
        public CybersourceUpdateProfile()
        {
            this.CreateMap<CaseManagementOrderStatusToPostToClient, CybersourceUpdate>()
                .ForMember(a => a.NewDecision, b => b.MapFrom(c => c.NewDecision.ConvertToAntiFraudEnum()))
                .ForMember(a => a.OriginalDecision, b => b.MapFrom(c => c.OriginalDecision.ConvertToAntiFraudEnum()));
        }
    }
}