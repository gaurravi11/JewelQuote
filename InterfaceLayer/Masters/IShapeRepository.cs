using ModelLayer.Masters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Masters
{
    public interface IShapeRepository
    {
        ShpModel GetShape(Int16 ShapeId);
        IEnumerable<ShpModel> GetAllShape();
        string AddShape(ShpModel shape);
        string UpdateShape(ShpModel shape);
        string DeleteShape(Int16 ShapeId);
    }
}
