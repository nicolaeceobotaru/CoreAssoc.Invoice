using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CoreAssoc.Invoice.Business.Commands;
using CoreAssoc.Invoice.Business.Models;
using CoreAssoc.Invoice.Business.Queries;
using CoreAssoc.Invoice.Common.Business;

namespace CoreAssoc.Invoice.Api.Controllers
{
    public class NotesController : BaseApiController
    {
        public NotesController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher) : base(commandDispatcher, queryDispatcher)
        {
        }

        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var query = new GetNoteQuery(id);
            var queryResult = _queryDispatcher.Handle<GetNoteQueryResult>(query);
            return Request.CreateResponse(HttpStatusCode.OK, queryResult.NoteModel);
        }

        [HttpGet]
        [Route("api/notes/invoiceId/{invoiceId}")]
        public HttpResponseMessage GetNotesForInvoiceId(int invoiceId)
        {
            var query = new GetNotesForInvoiceIdQuery(invoiceId);
            var queryResult = _queryDispatcher.Handle<GetNotesForInvoiceIdQueryResult>(query);
            return Request.CreateResponse(HttpStatusCode.OK, queryResult.NoteModels);
        }

        [HttpPost]
        public HttpResponseMessage Insert([FromBody] NoteModel noteModel)
        {
            var command = new CreateNoteCommand(noteModel);
            _commandDispatcher.Handle(command);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPut]
        public HttpResponseMessage Update([FromBody] NoteModel noteModel)
        {
            var command = new UpdateNoteCommand(noteModel);
            _commandDispatcher.Handle(command);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
