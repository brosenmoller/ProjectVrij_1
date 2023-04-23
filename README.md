## Unity Version
2021.3.23f1

## Git rules

1. Always pull before pushing new changes
2. Always push to the "develop" branch, never to main
3. When editing a scene: 
   - Create a duplicate of the scene then overwrite the original scene with a pull.
   - Implement the changes from your duplicate scene into the original scene. 
   - Delete the copy and push your changes.

## Code Rules

1. Default C# Rules
2. Always use `[SerializeField]` for serializing private members to the inspector
3. Always put Atributes in front of variables and 1 line above functions and classes
4. Always mark as private and/or readonly if possible
5. Always put the curly brace on the next line
8. All names must be descriptive
9. Never use magic variables
