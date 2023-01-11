using FirstLibrary;



Student student = new();


#region Default Access Modifiers
// Olusturulan bir class veya enum'a herhangi bir erisim belirleyicisi belirtilmezde varsayilan olarak 'internal' atanmaktadir.
// Class icerisinde tanimlanan bir property yada method'a herhangi bir erisim belirleyicisi belirtilmezde varsayilan olarak 'private' atanmaktadir.
#endregion

#region Private
// Sadece class icerisinden erisilebilir.
// student.Surname =>Surname property'si private oldugu icin erisilemedi
#endregion

#region Public
// Ayni proje icerisinden yada referans alinan baska projelerden erisilebilir.
// student.Name => Name property'si public oldugu icin erisilebildi

#endregion

#region Internal
// Ayni proje (Assembly) icerisinde heryerden erisilebilir.
// student.Age => Age property'si internal oldugu icin erisilemez. Cunku farkli bir assemblyde.
#endregion

#region Protected
// Ayni veya farkli assembly icerisinden ve miras alinmasi halinde erisilebilir. Nesne ornegi uzerinden erisilemez.

class Person : Student
{
    public Person()
    {
        this.BirthDate = DateTime.Now; // BirthDate prooerty'si protected oldugu icin erisilebildi.
    }
}

#endregion

#region Protected Internal
// Ayni veya farkli assembly icerisinden ve miras alinmasi halinde erisilebilir.Nesne ornegi uzerinden erisilebilir.

class People : Student
{
    public People()
    {
        this.FatherName = "Osman";
    }
}


#endregion

#region Private Protected
// Sadece kendi assembly uzerinden miras alinacak erisilir.
#endregion