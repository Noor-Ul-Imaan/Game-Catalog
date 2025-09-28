using System.ComponentModel.DataAnnotations;

namespace GameStore.Dtos;

public record class CreateGameDto(
    [Required][StringLength(50)] string Name,
    [Required][StringLength(20)] string Genre,
    [Range(1, 100)] decimal Price,
    DateOnly ReleaseDate);

//data notations to attributes that can be applied to properties to define whats expected of them
//like 'required'