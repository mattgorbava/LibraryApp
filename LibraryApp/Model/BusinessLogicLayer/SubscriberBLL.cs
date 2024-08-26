using LibraryApp.Model.DataAccessLayer;
using LibraryApp.Model.Entities;
using System.Collections.ObjectModel;

namespace LibraryApp.Model.BusinessLogicLayer
{
    internal class SubscriberBLL
    {
        private readonly SubscriberDAL subscriberDAL;

        public SubscriberBLL()
        {
            subscriberDAL = new SubscriberDAL();
        }

        public ObservableCollection<Subscriber> GetSubscribers()
        {
            ObservableCollection<Subscriber> subscribers = new ObservableCollection<Subscriber>();
            foreach (var subscriber in subscriberDAL.GetSubscribers()) 
                subscribers.Add(subscriber);
            return subscribers;
        }

        public void AddSubscriber(Subscriber subscriber)
        {
            subscriberDAL.AddSubscriber(subscriber);
        }

        public void EditSubscriber(Subscriber subscriber)
        {
            subscriberDAL.EditSubscriber(subscriber);
        }

        public bool SubscriberExists(string name, int personId = 0)
        {
            var subscribers = GetSubscribers();
            return subscribers.Any(subscriber => subscriber.Name == name && subscriber.PersonId != personId);
        }

        public void ToggleRegistered(Subscriber subscriber)
        {
            subscriberDAL.EditSubscriber(subscriber);
        }
    }
}
