import React from "react";
import { CommonButton, CommonButtonProps } from "../../atoms/CommonButton";
import { DefaultCommonButtonPanel } from "./styles";

export type CommonButtonPanelProps = {
    buttons: Array<CommonButtonProps>;
};

export const CommonButtonPanel: React.FC<CommonButtonPanelProps> = (props: CommonButtonPanelProps) => {
    return (
        <DefaultCommonButtonPanel>
            {
                props.buttons.map((button, i) => (
                    <CommonButton 
                        key={i}
                        text={button.text}
                        onClick={button.onClick} />
                ))
            }
        </DefaultCommonButtonPanel>
    );
}