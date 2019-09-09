using OrchardCore.Modules.Manifest;

[assembly: Module(
    Name = "Elsa Workflows",
    Author = "Sipke Schoorstra",
    Website = "https://github.com/elsa-workflows/elsa-core",
    Version = "1.0.0",
    Description = "The Elsa Workflows module provides workflow management tools.",
    Category = "Elsa Workflows"
)]

[assembly: Feature(
    Id = "OrchardCore.Elsa",
    Name = "Elsa Workflows",
    Description = "The Elsa Workflows module provides workflow management tools.",
    Dependencies = new string[0],
    Category = "Elsa Workflows"
)]