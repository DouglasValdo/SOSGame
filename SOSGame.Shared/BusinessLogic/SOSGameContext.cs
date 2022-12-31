using System.Text;

namespace SOSGame.Shared.BusinessLogic;

public class SOSGameContext
{
    private readonly IGameConfigurationEntity _sOSGameConfigurations;
    private BoxEntity[] _possitions;
    private readonly int _numberOfBoxes;
    private const string WINCOMBINATION = "SOS";

    private SOSGameContext() { }

    public SOSGameContext(IGameConfigurationEntity configurationEntity)
    {
        _sOSGameConfigurations = configurationEntity;
        _numberOfBoxes= _sOSGameConfigurations.GameNumberOfBoxes;
        _possitions = new BoxEntity[_numberOfBoxes];
    }

    public bool Play(BoxEntity boxEntity)
    {
        //check if the selected box will make an SOS
        if (CheckSOS(boxEntity))
            return true;
        else
            //Register the Play if is not SOS
            RegisterThePlay(boxEntity);

        return false;
    }

    private void RegisterThePlay(BoxEntity selectedBox)
    {
        _possitions[selectedBox.Index] = selectedBox;
    }

    private bool CheckSOS(BoxEntity boxEntity)
    {
        List<BoxEntity> selectedBoxes = GetSelectedBoxes(boxEntity).ToList();

        for (int x = 0; x < selectedBoxes.Count - 1; x++)
        {
            if (selectedBoxes[x] == null) continue;

            if (IsSOS(GetPossibleSOS(x, selectedBoxes)))
                return true;
        }

        return false;
    }
    private string GetPossibleSOS(int currentBoxIndex, List<BoxEntity> possibleSOS)
    {
        StringBuilder strPossibleSOS = new();

        strPossibleSOS.EnsureCapacity(3);

        for (int x = currentBoxIndex; x < (currentBoxIndex + 3); x++)
        {
            if (x > possibleSOS.Count - 1) return strPossibleSOS.ToString();

            if (possibleSOS[x] == null || possibleSOS[x].Letter == char.MinValue)
            {
                strPossibleSOS.Clear();
                continue;
            }

            char? lastLetter = strPossibleSOS.Length == 0 ? char.MinValue :
                strPossibleSOS[strPossibleSOS.Length - 1];

            if (lastLetter == null || lastLetter.Equals(possibleSOS[x].Letter))
                continue;

            strPossibleSOS.Append(possibleSOS[x].Letter);
        }

        return strPossibleSOS.ToString();

    }

    private bool IsSOS(string str)
    {
        return str.ToString().Equals(WINCOMBINATION);
    }

    private BoxEntity[] GetSelectedBoxes(BoxEntity selectedBox)
    {
        switch (selectedBox.Index.Value)
        {
            case 0:
                return new BoxEntity[] { selectedBox, _possitions[1], _possitions[2] };
            case 1:
                return new BoxEntity[] { _possitions[0], selectedBox, _possitions[2], _possitions[3] };
        }

        if (selectedBox.Index.Value == _possitions.Length - 1)
            return new BoxEntity[] { selectedBox, _possitions[selectedBox.Index.Value - 1], _possitions[selectedBox.Index.Value - 2] };
        else if (selectedBox.Index.Value == _possitions.Length - 2)
            return new BoxEntity[] { selectedBox, _possitions[selectedBox.Index.Value - 1], _possitions[selectedBox.Index.Value - 2] };

        else
            return new BoxEntity[] {
                _possitions[selectedBox.Index.Value - 2],
                _possitions[selectedBox.Index.Value - 1],
                selectedBox,
                _possitions[selectedBox.Index.Value + 1],
                _possitions[selectedBox.Index.Value + 2],
            };

    }
}
