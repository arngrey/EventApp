import React from "react";
import { CommonTableRowContainer, CommonTableRowContainerProps } from "./styles";
import { CommonTableCell } from "../../atoms/CommonTableCell";


export type CommonTableRowProps = {
    values: Array<string>;
    containerProps: CommonTableRowContainerProps;
    onClick: () => void;
}

export const CommonTableRow: React.FC<CommonTableRowProps> = (props) => {
    return (
        <CommonTableRowContainer
            height={props.containerProps.height}
            onClick={() => { props.onClick(); }}>
            {
                props.values.map((value, i) => (
                    <CommonTableCell key={i} value={value}></CommonTableCell>
                ))
            }
        </CommonTableRowContainer>
    );
}