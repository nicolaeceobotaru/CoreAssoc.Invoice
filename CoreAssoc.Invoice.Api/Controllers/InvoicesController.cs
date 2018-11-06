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
    public class InvoicesController : BaseApiController
    {
        public InvoicesController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher) : base(commandDispatcher, queryDispatcher)
        {
        }

        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var query = new GetInvoiceQuery(id);
            var queryResult = _queryDispatcher.Handle<GetInvoiceQueryResult>(query);
            return Request.CreateResponse(HttpStatusCode.OK, queryResult.InvoiceModel);
        }

        [HttpPost]
        public HttpResponseMessage Insert([FromBody] InvoiceModel invoiceModel)
        {
            var command = new CreateInvoiceCommand(invoiceModel);
            _commandDispatcher.Handle(command);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPut]
        public HttpResponseMessage Update([FromBody] InvoiceModel invoiceModel)
        {
            var command = new UpdateInvoiceCommand(invoiceModel);
            _commandDispatcher.Handle(command);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
