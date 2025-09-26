using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace QUANLYBANHANG
{
    public class CART
    {
        private readonly Dictionary<string, ITEM> _items = new Dictionary<string, ITEM>();

        public IReadOnlyDictionary<string, ITEM> Items => _items;

        public void Add(string id, string name, string img, int qty, decimal price)
        {
            if (_items.ContainsKey(id)) _items[id].SOLUONG += qty;
            else _items[id] = new ITEM { MASANPHAM = id, TENSANPHAM = name, HINHANH = img, SOLUONG = qty, DONGIA = price };
        }

        public void Update(string id, int qty)
        {
            if (_items.ContainsKey(id))
            {
                if (qty <= 0) _items.Remove(id);
                else _items[id].SOLUONG = qty;
            }
        }

        public void Remove(string id) { if (_items.ContainsKey(id)) _items.Remove(id); }

        public decimal Total()
        {
            decimal s = 0;
            foreach (var it in _items.Values) s += it.THANHTIEN;
            return s;
        }

        public DataTable ToDataTable()
        {
            var dt = new DataTable();
            dt.Columns.Add("MASANPHAM");
            dt.Columns.Add("TENSANPHAM");
            dt.Columns.Add("HINHANH");
            dt.Columns.Add("SOLUONG", typeof(int));
            dt.Columns.Add("DONGIA", typeof(decimal));
            dt.Columns.Add("THANHTIEN", typeof(decimal));
            foreach (var it in _items.Values)
                dt.Rows.Add(it.MASANPHAM, it.TENSANPHAM, it.HINHANH, it.SOLUONG, it.DONGIA, it.THANHTIEN);
            return dt;
        }
    }
}