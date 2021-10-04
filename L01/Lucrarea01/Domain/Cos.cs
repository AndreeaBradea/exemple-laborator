using CSharp.Choices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucrarea01.Domain
{
    [AsChoice]
    public static partial class Cos
    {
        public interface ICos
        {   }

        public record CosNevalid(IReadOnlyCollection<ProduseNevalidate> ProduseList, DetaliiC DetaliiC) : ICos;

        public record CosInvalid(IReadOnlyCollection<ProduseNevalidate> ProduseList, string reason) : ICos;

        public record CosGol(IReadOnlyCollection<ProduseNevalidate> ProduseList, string reason) : ICos;
        
        public record CosValid(IReadOnlyCollection<ProduseValidate> ProduseList, DetaliiC DetaliiC) : ICos;

        public record CosPlatit(IReadOnlyCollection<ProduseValidate> ProduseList, DetaliiC DetaliiC, DateTime PublishedDate) : ICos;

    }
}
