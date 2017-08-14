﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ServiceContracts;
using win10Core.Business.DataAccess;

namespace Services.ControllersApi
{
    public class ParentApiController : ApiController
    {
        private readonly IParentDataAccess _parentDataAccess;

        public ParentApiController(IParentDataAccess parentDataAccess)
        {
            _parentDataAccess = parentDataAccess;
        }
        // GET: api/ParentApi
        public IEnumerable<Parent> Get()
        {
            var getData = _parentDataAccess.Get();
            var response = getData
                .Select(c => new Parent() { ParentId = c.ParentId, Name = c.Name, Email = c.Email, FamilyId = c.FamilyId}).ToList();
            return response;   

        }

        // GET: api/ParentApi/5
        public Parent Get(int id)
        {
            var getData = _parentDataAccess.Get(id);
            var response = new Parent() { ParentId = getData.ParentId, FamilyId = getData.FamilyId, Name = getData.Name, Email = getData.Email };
            return response;
        }

        // POST: api/ParentApi
        public Parent Post(Parent parent)
        {
            var getData = _parentDataAccess.Insert(new win10Core.Business.Model.Parent() {Name = parent.Name, Email = parent.Email, FamilyId = parent.FamilyId});
            var response = new Parent { ParentId = getData.ParentId, Name = getData.Name, Email = getData.Email, FamilyId = getData.FamilyId};
            return response;
        }

        // PUT: api/ParentApi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ParentApi/5
        public void Delete(int id)
        {
        }
    }
}
