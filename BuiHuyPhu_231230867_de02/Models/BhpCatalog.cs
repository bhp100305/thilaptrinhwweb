using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BuiHuyPhu_231230867_de02.Models;

public partial class BhpCatalog
{
    public int HvtId { get; set; }

    [Required(ErrorMessage = "Tên danh mục không được để trống")]
    [StringLength(100, ErrorMessage = "Tên danh mục không được vượt quá 100 ký tự")]
    public string HvtCateName { get; set; } = null!;

    [Required(ErrorMessage = "Giá không được để trống")]
    [Range(100, 5000, ErrorMessage = "Giá phải nằm trong khoảng 100 đến 5000")]
    public int? HvtCatePrice { get; set; }

    [Required(ErrorMessage = "Số lượng không được để trống")]
    [Range(1, int.MaxValue, ErrorMessage = "Số lượng phải lớn hơn 0")]
    public int HvtCateQty { get; set; }

    [Required(ErrorMessage = "Vui lòng chọn ảnh")]
    [RegularExpression(@".*\.(jpg|png|gif|tiff)$", ErrorMessage = "Ảnh phải có đuôi .jpg, .png, .gif hoặc .tiff")]
    public string? HvtPicture { get; set; }

    public bool HvtCateActive { get; set; }


    // ✅ Thêm thuộc tính phụ để hiển thị “Active / Non-Active”
    public string HvtCateActiveText
    {
        get
        {
            return HvtCateActive == true ? "Active" : "Non-Active";
        }
    }

    public int? HvtTotalPrice
    {
        get
        {
            return (HvtCatePrice ?? 0) * HvtCateQty;
        }
    }
}
