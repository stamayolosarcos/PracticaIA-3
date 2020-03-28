using UnityEngine;
using Steerings;

namespace FSM
{
    [RequireComponent(typeof(BOB_Blackboard))]
    [RequireComponent(typeof(Arrive))]

    public class FSM_BobWork : FiniteStateMachine
    {
        public enum State { INITIAL, GOTOAREA, PICKBOX, TRANSPORTBOX, TERMINATED, FAILED};
        public State currentState = State.INITIAL;

        private Arrive arrive;
        private BOB_Blackboard blackboard;

        private GameObject box;
        private GameObject boxArea;
        private GameObject warehouse;

        public float arrivedToTarget = 5;
        [HideInInspector]public int boxesDelivered = 0;

        void Start()
        {
            arrive = GetComponent<Arrive>();
            blackboard = GetComponent<BOB_Blackboard>();
            arrive.enabled = false;

            boxArea = blackboard.boxArea;
            warehouse = blackboard.warehouse;
        }

        public override void Exit()
        {
            arrive.enabled = false;
            if (box != null)
            {
                box.transform.parent = null;
                box = null;
            }
            boxesDelivered = 0;
            base.Exit();
        }

        public override void ReEnter()
        {
            currentState = State.INITIAL;
            base.ReEnter();
        }

        void Update()
        {
            if (boxesDelivered >= 3) ChangeState(State.TERMINATED);
            if (GameObject.FindGameObjectWithTag("BOX") == null) ChangeState(State.FAILED);
            switch (currentState)
            {
                case State.INITIAL:
                    ChangeState(State.GOTOAREA);
                    break;
                case State.GOTOAREA:
                    box = SensingUtils.FindInstanceWithinRadius(this.gameObject, "BOX", blackboard.findObjectRadius);
                    if (box != null)
                    {
                        ChangeState(State.PICKBOX);
                        break;
                    }
                    break;
                case State.PICKBOX:
                    if (arrivedToTarget > Mathf.Abs(Vector3.Distance(transform.position, box.transform.position)))
                    {
                        ChangeState(State.TRANSPORTBOX);
                        break;
                    }
                    break;
                case State.TRANSPORTBOX:
                    if (arrivedToTarget > Mathf.Abs(Vector3.Distance(transform.position, blackboard.warehouse.transform.position)))
                    {
                        ChangeState(State.GOTOAREA);
                        break;
                    }
                    break;
            }
        }

        void ChangeState(State newState)
        {
            switch (currentState)
            {
                case State.PICKBOX:
                    box.transform.parent = transform;
                    break;
                case State.TRANSPORTBOX:
                    if (box != null)
                    {
                        box.transform.parent = null;
                        box.tag = "DROPPED";
                        box = null;
                        boxesDelivered++;
                    }
                    break;
            }
            switch (newState)
            {
                case State.GOTOAREA:
                    arrive.enabled = true;
                    arrive.target = boxArea;
                    break;
                case State.PICKBOX:
                    arrive.enabled = true;
                    arrive.target = box;
                    break;
                case State.TRANSPORTBOX:
                    arrive.enabled = true;
                    arrive.target = warehouse;
                    break;
                case State.FAILED:
                    arrive.enabled = false;
                    break;
                case State.TERMINATED:
                    arrive.enabled = false;
                    break;
            }

            currentState = newState;
        }
    }
}