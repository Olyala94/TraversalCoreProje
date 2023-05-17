﻿using MediatR;
using System.Collections.Generic;
using TraversalCoreProje.CQRS.Result.GuideResults;

namespace TraversalCoreProje.CQRS.Queries.GuideQueries
{
    public class GetAllGuideQuery:IRequest<List<GetAllGuideQueryResult>>
    {

    }
}
