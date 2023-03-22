using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface CharacterDI
{
    CharacterComponentDI GetCharacterComponent();
    CharacterStatsDI GetStatComponent();
 
}
