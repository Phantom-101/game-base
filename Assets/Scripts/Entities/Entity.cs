using System.Collections.Generic;

public class Entity : IEntity {

    public bool AddBehaviour (IEntityBehaviour behaviour) {
        throw new System.NotImplementedException ();
    }

    public bool AddBehaviour<T> () {
        throw new System.NotImplementedException ();
    }

    public bool AddDatum (IEntityDatum datum) {
        throw new System.NotImplementedException ();
    }

    public bool AddDatum<T> () {
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

    public IEntityBehaviour GetBehaviour<T> (bool inherited) {
        throw new System.NotImplementedException ();
    }

    public List<IEntityBehaviour> GetBehaviours () {
        throw new System.NotImplementedException ();
    }

    public List<IEntityBehaviour> GetBehaviours<T> (bool inherited) {
        throw new System.NotImplementedException ();
    }

    public List<IEntityDatum> GetData<T> (bool inherited) {
        throw new System.NotImplementedException ();
    }

    public List<IEntityDatum> GetDatum () {
        throw new System.NotImplementedException ();
    }

    public IEntityDatum GetDatum<T> (bool inherited) {
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

    public bool PossessesDatum (IEntityDatum datum) {
        throw new System.NotImplementedException ();
    }

    public bool PossessesDatum<T> (bool inherited) {
        throw new System.NotImplementedException ();
    }

    public bool RemoveBehaviour (IEntityBehaviour behaviour) {
        throw new System.NotImplementedException ();
    }

    public bool RemoveBehaviour<T> (bool inherited) {
        throw new System.NotImplementedException ();
    }

    public bool RemoveBehaviours<T> (bool inherited) {
        throw new System.NotImplementedException ();
    }

    public bool RemoveData<T> (bool inherited) {
        throw new System.NotImplementedException ();
    }

    public bool RemoveDatum (IEntityDatum datum) {
        throw new System.NotImplementedException ();
    }

    public bool RemoveDatum<T> (bool inherited) {
        throw new System.NotImplementedException ();
    }

}
