using System;
using System.Collections.Generic;

public interface IPersonService{
    void Create(PersonModel person);

    void Update(PersonModel person);

    string Delete(Guid id);

    PersonModel findOne(Guid id);

    List<PersonModel> GetAll();
}