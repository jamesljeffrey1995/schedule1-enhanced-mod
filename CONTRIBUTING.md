# Contributing to Schedule 1 Enhanced Mod

Thank you for your interest in contributing! This document provides guidelines for contributing to the project.

## Getting Started

1. Fork the repository
2. Clone your fork
3. Create a new branch for your feature/fix
4. Make your changes
5. Test your changes in-game
6. Submit a pull request

## Development Environment Setup

### Prerequisites
- Visual Studio 2022 or Rider
- .NET Framework 6.0 SDK
- Schedule 1 game installed
- MelonLoader installed in your Schedule 1 directory
- S1API installed

### Building the Project
```bash
dotnet build Schedule1EnhancedMod.sln
```

### Testing Your Changes
1. Build the project
2. Copy `bin/Debug/Schedule1EnhancedMod.dll` to your `Schedule 1/Mods/` folder
3. Launch the game through Steam
4. Check the MelonLoader console for any errors
5. Test your changes in-game

## Code Style Guidelines

- Use meaningful variable and method names
- Add XML documentation comments for public APIs
- Keep methods focused and single-purpose
- Use regions to organize code logically
- Follow C# naming conventions:
  - PascalCase for class names, method names, properties
  - camelCase for local variables and parameters
  - _camelCase for private fields

## Pull Request Guidelines

- Provide a clear description of the changes
- Reference any related issues
- Include testing steps
- Keep PRs focused on a single feature/fix
- Update documentation if needed

## Issue Guidelines

When reporting bugs:
- Include your Schedule 1 version
- Include your MelonLoader version
- Include your S1API version
- Describe expected vs actual behavior
- Include relevant log output from MelonLoader console

When suggesting features:
- Explain the use case
- Describe the desired functionality
- Consider compatibility with existing features

## Questions?

Feel free to open an issue for questions or join the Schedule 1 modding community Discord for help.
