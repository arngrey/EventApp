import React, { useState } from 'react';
import './App.css';
import { useAppDispatch } from './app/hooks';
import { loadCampaignsAsync, loadHobbiesAsync, loadCampaignMessagesAsync, sendMessageAsync, createUserAsync, createHobbyAsync, addParticipantAsync, createCampaignAsync } from './app/slice';

function App() {
  const dispatch = useAppDispatch();
  // const campaigns = useAppSelector(selectCampaigns);
  const [campaignId, setCampaignId] = useState<string>("");
  const [userId, setUserId] = useState<string>("");
  const [text, setText] = useState<string>("");
  const [hobbyIds, setHobbyIds] = useState<string>("");

  return (
    <div>
      <button onClick={() => {dispatch(loadCampaignsAsync())}}>
        Получить список кампаний
      </button>
      <button onClick={() => {dispatch(loadHobbiesAsync())}}>
        Получить список хобби
      </button>
      <button onClick={() => {dispatch(loadCampaignMessagesAsync(campaignId))}}>
        Получить список сообщений кампании
      </button>
      <button onClick={() => {dispatch(sendMessageAsync(userId, campaignId, text))}}>
        Отправить сообщение
      </button>
      <button onClick={() => {dispatch(createUserAsync(text))}}>
        Создать пользователя
      </button>
      <button onClick={() => {dispatch(createHobbyAsync(text))}}>
        Создать хобби
      </button>
      <button onClick={() => {dispatch(addParticipantAsync(userId, campaignId))}}>
        Добавить участника в кампанию
      </button>
      <button onClick={() => {dispatch(createCampaignAsync(text, userId, hobbyIds.split(",")))}}>
        Создать кампанию
      </button>      
      <br />
      <label htmlFor="">Введите идентификатор пользователя.</label>
      <input type="text" onChange={(e) => setUserId(e.target.value)} />      
      <label htmlFor="">Введите идентификатор кампании.</label>
      <input type="text" onChange={(e) => setCampaignId(e.target.value)} />
      <label htmlFor="">Введите текст.</label>
      <input type="text" onChange={(e) => setText(e.target.value)} />
      <label htmlFor="">Введите хобби через ",".</label>
      <input type="text" onChange={(e) => setHobbyIds(e.target.value)} />
    </div>
  );
}

export default App;
