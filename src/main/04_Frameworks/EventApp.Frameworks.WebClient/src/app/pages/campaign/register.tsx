import React, { useEffect, useState } from "react";
import { FieldForm } from "../../components/organisms/FieldForm";
import { Table } from "../../components/organisms/Table";
import { RegisterContainer } from "../styles";
import { useAppDispatch, useAppSelector } from '../../../app/hooks';
import { loadCampaignsAsync, loadCampaignMessagesAsync, createCampaignAsync, selectCampaigns } from '../../../app/slice';
import { Popup } from "../../components/atoms/Popup";
import { CampaignCard } from "./Card";
import { useLocation } from "react-router-dom";
import { selectAuthentication } from "../../modules/authentication/selectors";

export const CampaignRegister: React.FC = () => {
    const dispatch = useAppDispatch();
    
    const location = useLocation();
    useEffect(() => {
        dispatch(loadCampaignsAsync());
    }, [location]);

    const authentication = useAppSelector(selectAuthentication);
    const campaigns = useAppSelector(selectCampaigns);
    const [campaignId, setCampaignId] = useState<string>("");
    const [isAddingCampaignPopupVisible, setAddingCampaignPopupVisibility] = useState<boolean>(false);
    const [isCardPopupVisible, setCardPopupVisibility] = useState<boolean>(false);

    if (!authentication.isAuthenticated) {
        return null;
    }

    return (
        <RegisterContainer>
            <Table
                title={"Список кампаний"}
                columnNames={["Идентификатор", "Наименование", "Участники", "Хобби"]}
                rows={campaigns.map((campaign: any) => [
                    campaign.id, 
                    campaign.name, 
                    campaign.participants.map((p:any) => p.login).join(", "),
                    campaign.hobbies.map((p:any) => p.name).join(", ")
                ])}
                rowHeight={"1rem"}
                headersHeight={"2rem"}
                buttonPanel={{ buttons: [ 
                    { text: "Добавить кампанию", onClick: () => { setAddingCampaignPopupVisibility(true); } }
                ] }}
                onRowClick={(row) => {
                    setCampaignId(row[0]); 
                    setCardPopupVisibility(true);
                    dispatch(loadCampaignMessagesAsync(row[0]));
                }} />
            <Popup isVisible={isAddingCampaignPopupVisible}>
                <FieldForm 
                    title={"Создание кампании"}
                    inputFields={[
                        { labelText: "Наименование", name: "name" },
                        { labelText: "Идентификаторы хобби через \",\"", name: "hobbyIds" }
                    ]}
                    onOk={async (records) => { 
                        await dispatch(createCampaignAsync(records["name"], authentication.userId, records["hobbyIds"].split(",")));
                        await dispatch(loadCampaignsAsync());
                        setAddingCampaignPopupVisibility(false);
                    }}
                    onCancel={() => { setAddingCampaignPopupVisibility(false); }} />
            </Popup>          
            <Popup isVisible={isCardPopupVisible}>
                 <CampaignCard
                    campaignId={campaignId}
                    onClose={() => { setCardPopupVisibility(false); }} />
            </Popup>            
        </RegisterContainer>
    )
}