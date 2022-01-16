import React, { useEffect, useState } from "react";
import { FieldForm } from "../../components/organisms/FieldForm";
import { CommonTable } from "../../components/organisms/CommonTable";
import { RegisterContainer } from "../styles";
import { useAppDispatch, useAppSelector } from '../../hooks';
import { loadCampaignsAsync, loadCampaignMessagesAsync, createCampaignAsync } from '../../slice';
import { Popup } from "../../components/atoms/Popup";
import { CampaignCard } from "./Card";
import { useLocation } from "react-router-dom";
import { selectAuthentication } from "../../modules/authentication/selectors";
import { selectCampaigns, selectHobbies } from "../../selectors";

export const CampaignRegister: React.FC = () => {
    const dispatch = useAppDispatch();
    
    const location = useLocation();
    useEffect(() => {
        dispatch(loadCampaignsAsync());
    }, [location]);

    const authentication = useAppSelector(selectAuthentication);
    const campaigns = useAppSelector(selectCampaigns);
    const hobbies = useAppSelector(selectHobbies);
    const [campaignId, setCampaignId] = useState<string>("");
    const [isAddingCampaignPopupVisible, setAddingCampaignPopupVisibility] = useState<boolean>(false);
    const [isCardPopupVisible, setCardPopupVisibility] = useState<boolean>(false);

    if (!authentication.isAuthenticated) {
        return null;
    }

    return (
        <RegisterContainer>
            <CommonTable
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
                    fields={[
                        { name: "name", type: "input", props: { labelText: "Наименование" } },
                        { name: "hobbyIds", type: "select", props: { labelText: "Идентификаторы хобби", options: hobbies.map(hobby => ({ value: hobby.id, label: hobby.name })), isMultiple: true } },
                    ]}
                    buttons={[
                        { 
                            text: "Создать", 
                            onClick: async (records) => { 
                                await dispatch(createCampaignAsync(records["name"], authentication.userId, records["hobbyIds"]));
                                await dispatch(loadCampaignsAsync());
                                setAddingCampaignPopupVisibility(false);
                            }
                        }, {
                            text: "Отмена", 
                            onClick: async (records) => { 
                                setAddingCampaignPopupVisibility(false);
                            }
                        }
                    ]} />
            </Popup>          
            <Popup isVisible={isCardPopupVisible}>
                 <CampaignCard
                    campaignId={campaignId}
                    onClose={() => { setCardPopupVisibility(false); }} />
            </Popup>            
        </RegisterContainer>
    )
}