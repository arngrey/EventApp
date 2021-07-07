import React from "react";
import { useAppDispatch } from '../../app/hooks';
import { loadCampaignsAsync } from "./tableSlice";

export interface TableProps {

}

export const Table: React.FC = () => {
  const dispatch = useAppDispatch();

  return (
    <button onClick={() => { debugger; dispatch(loadCampaignsAsync())}}>
      Получить список кампаний
    </button>
  )
}