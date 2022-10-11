using UnityEngine;

namespace Scripts.Location_Generator
{
    public class RootGenerator :MonoBehaviour
    {
        [SerializeField] private GeneratorLocationView _generatorLocationView;

         private GeneratorLocationController _generatorLocationController;

        private void Awake()
        {
            _generatorLocationController = new GeneratorLocationController(_generatorLocationView);
            _generatorLocationController.Awake();
        }
    }
}