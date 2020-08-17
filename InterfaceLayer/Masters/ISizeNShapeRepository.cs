using ModelLayer.Masters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Masters
{
    public interface ISizeNShapeRepository
    {
        ShapeModel GetShapeNSize(Int16 ShapeId);
        IEnumerable<ShapeModel> GetAllShapeNSize();
        DataTable GetAllShapeNSize_dt();
        string AddShapeNSize(ShapeModel shape);
        string UpdateShapeNSize(ShapeModel shape);
        string DeleteShapeNSize(Int16 ShapeId);
    }
}
