namespace SchoolAdersonDeMenezes.Application.Dtos.InputModels
{
    public record StudentInputModel
    (
         Guid Id,
         string FullName,
         string Email,
         ParentsInputModel Parents
    );
}
