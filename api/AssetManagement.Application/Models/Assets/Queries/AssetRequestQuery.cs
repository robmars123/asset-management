using AssetManagement.Application.Generics;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Application.Models.Assets.Queries
{
    public class AssetRequestQuery : IRequest<QueryResult<List<AssetRequestResult>>>
    {
    }
}
