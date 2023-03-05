﻿using AutoMapper;
using MediatR;
using TestApp.Domain.Abstraction.UnitOfWorks;
using TestApp.Domain.Model.Dtos.Authors;
using TestApp.Domain.Model.Queries.Authors;

namespace TestApp.Domain.Handlers.Authors
{
    public class GetAuthorsQueryHandler : IRequestHandler<GetAuthorsQuery, List<GetAuthorDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAuthorsQueryHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper;
        }
        public async Task<List<GetAuthorDto>> Handle(GetAuthorsQuery request, CancellationToken cancellation)
        {
            var authors = await _unitOfWork.AuthorRepository.AllAsync(null, cancellation);

            return _mapper.Map<List<GetAuthorDto>>(authors);
        }
    }
}
