using SchoolAdersonDeMenezes.Domain.Enums;

namespace SchoolAdersonDeMenezes.Application.Dtos.InputModels
{
    public record ParentsInputModel
    ( 
        Guid Id,
        Guid StudentId,
        string FullName,
        string Email,
        Parent Parent
    );
}
