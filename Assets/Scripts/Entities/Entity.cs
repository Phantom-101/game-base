using System.Collections.Generic;

public class Entity : IEntity {

    public bool AddBehaviour (IEntityBehaviour behaviour) {
        throw new System.NotImplementedException ();
    }

    public bool AddBehaviour<T> () {
        throw new System.NotImplementedException ();
    }

    public bool AddData (IEntityData data) {
        throw new System.NotImplementedException ();
    }

    public bool AddData<T> () {
        throw new System.NotImplementedException ();
    }

    public int CountBehaviours () {
        throw new System.NotImplementedException ();
    }

    public int CountBehaviours<T> (bool inherited) {
        throw new System.NotImplementedException ();
    }

    public int CountData () {
        throw new System.NotImplementedException ();
    }

    public int CountData<T> () {
        throw new System.NotImplementedException ();
    }

    public List<IEntityBehaviour> GetAllBehaviours () {
        throw new System.NotImplementedException ();
    }

    public List<IEntityBehaviour> GetAllBehaviours<T> (bool inherited) {
        throw new System.NotImplementedException ();
    }

    public List<IEntityData> GetAllData () {
        throw new System.NotImplementedException ();
    }

    public List<IEntityData> GetAllData<T> (bool inherited) {
        throw new System.NotImplementedException ();
    }

    public IEntityBehaviour GetBehaviour<T> (bool inherited) {
        throw new System.NotImplementedException ();
    }

    public IEntityData GetData<T> (bool inherited) {
        throw new System.NotImplementedException ();
    }

    public string GetIdentifier () {
        throw new System.NotImplementedException ();
    }

    public string GetName () {
        throw new System.NotImplementedException ();
    }

    public List<IEntity> GetSubEntities () {
        throw new System.NotImplementedException ();
    }

    public IEntity GetSuperEntity () {
        throw new System.NotImplementedException ();
    }

    public bool PossessesBehaviour (IEntityBehaviour behaviour) {
        throw new System.NotImplementedException ();
    }

    public bool PossessesBehaviour<T> (bool inherited) {
        throw new System.NotImplementedException ();
    }

    public bool PossessesData (IEntityData data) {
        throw new System.NotImplementedException ();
    }

    public bool PossessesData<T> (bool inherited) {
        throw new System.NotImplementedException ();
    }

    public bool RemoveAllBehaviours<T> (bool inherited) {
        throw new System.NotImplementedException ();
    }

    public bool RemoveAllData<T> (bool inherited) {
        throw new System.NotImplementedException ();
    }

    public bool RemoveBehaviour (IEntityBehaviour behaviour) {
        throw new System.NotImplementedException ();
    }

    public bool RemoveBehaviour<T> (bool inherited) {
        throw new System.NotImplementedException ();
    }

    public bool RemoveData (IEntityData data) {
        throw new System.NotImplementedException ();
    }

    public bool RemoveData<T> (bool inherited) {
        throw new System.NotImplementedException ();
    }

}
