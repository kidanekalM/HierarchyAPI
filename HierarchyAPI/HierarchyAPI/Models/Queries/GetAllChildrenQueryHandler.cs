﻿using Azure.Core;
using Dapper;
using MediatR;
using System.Reflection.Metadata;
namespace HierarchyAPI.Models.Queries
{
    public class GetAllChildrenQuery : IRequest<List<Role>>
    {
        public Guid guid { get; set; }
    }
    public class GetAllChildrenQueryHandler:IRequestHandler<GetAllChildrenQuery, List<Role>>
    {
        private readonly Repositories.IRoleQueryRepository _repository;
        public GetAllChildrenQueryHandler(Repositories.IRoleQueryRepository roleQueryRepository)
        {
            _repository = roleQueryRepository;
        }
        public async Task<List<Role>> Handle(GetAllChildrenQuery request,CancellationToken cancellationToken)
        {
            return await _repository.GetAllChildren(request.guid);
        }
        public async Task<List<Role>> GetAllChildren(GetAllChildrenQuery request)
        {
           return await _repository.GetAllChildren(request.guid);
        }

    }
}
