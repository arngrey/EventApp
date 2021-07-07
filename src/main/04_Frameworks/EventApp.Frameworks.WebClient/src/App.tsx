import React from 'react';
import './App.css';
import { useAppSelector, useAppDispatch } from './app/hooks';
import { loadCampaignsAsync, selectCampaigns } from './app/slice';

function App() {
  const dispatch = useAppDispatch();
  const campaigns = useAppSelector(selectCampaigns);

  return (
    <div>
      <button onClick={() => {dispatch(loadCampaignsAsync())}}>
        Получить список кампаний
      </button>
      <textarea name="campaigns" id="campaigns" cols={30} rows={10}>
        {campaigns}
      </textarea>
    </div>
  );
}

export default App;
