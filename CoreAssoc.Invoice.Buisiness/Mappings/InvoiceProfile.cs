using AutoMapper;
using CoreAssoc.Invoice.Business.Models;
using CoreAssoc.Invoice.Data.Entities;

namespace CoreAssoc.Invoice.Business.Mappings
{
    public class InvoiceProfile : Profile
    {
        public InvoiceProfile()
        {
            CreateMap<InvoiceModel, Data.Entities.Invoice>()
                .ForMember(entity => entity.Id, map => map.MapFrom(model => model.InvoiceId));

            CreateMap<Data.Entities.Invoice, InvoiceModel>()
                .ForMember(model => model.InvoiceId, map => map.MapFrom(entity => entity.Id));

            CreateMap<NoteModel, Note>()
                .ForMember(entity => entity.Id, map => map.MapFrom(model => model.NoteId)).ReverseMap();

            CreateMap<Note, NoteModel>()
                .ForMember(model => model.NoteId, map => map.MapFrom(entity => entity.Id)).ReverseMap();
        }
    }
}